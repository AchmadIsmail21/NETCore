using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using NETCore.Context;
using NETCore.Models;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NETCore.ViewModel.RegisterVM;

namespace NETCore.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, string>
    {
        MyContext myContext;
        private readonly DbSet<RegisterVM> registers;
       
        public PersonRepository(MyContext myContext ) : base(myContext) {
            this.myContext = myContext;
            registers = myContext.Set<RegisterVM>();
            
        }
        private static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        private static string HashPassword(string password) {
            return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
        }

        /*private static bool ValidatePassword(string password, string correct) {
            return BCrypt.Net.BCrypt.Verify(password, correct);
        }*/

        public int Register(RegisterVM register)
        {
            var checkEmail = myContext.Persons.FirstOrDefault(p => p.Email == register.Email); //linq
            var checkPhone = myContext.Persons.FirstOrDefault(p => p.Phone == register.Phone);
            var checkNik = myContext.Persons.FirstOrDefault(p => p.NIK == register.NIK);
            var insert = 0;
            //var result = 0;
            if (checkEmail == null && checkPhone == null && checkNik == null)
            {
                Person person = new Person
                {
                    NIK = register.NIK,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Phone = register.Phone,
                    BirthDate = register.BirthDate,
                    gender = (Person.Gender)register.gender,
                    Salary = register.Salary,
                    Email = register.Email
                };
                myContext.Add(person);
                insert = myContext.SaveChanges();

                Account account = new Account
                {
                    NIK = person.NIK,
                    Password = HashPassword(register.Password)
                };
                myContext.Add(account);
                insert = myContext.SaveChanges();

                Education education = new Education
                {
                    Degree = register.Degree,
                    GPA = register.GPA,
                    UniversityId = register.UniversityId
                };
                myContext.Add(education);
                insert = myContext.SaveChanges();

                Profiling profiling = new Profiling
                {
                    NIK = person.NIK,
                    EducationId = education.Id
                };
                myContext.Add(profiling);
                insert = myContext.SaveChanges();

                AccountRole accountRole = new AccountRole
                {
                    AccountNIK = account.NIK,
                    RoleId = 1
                };
                myContext.Add(accountRole);
                insert = myContext.SaveChanges();
                
                return insert;
            }
            else if (checkEmail != null)
            {
                return 100;
            }
            else if (checkNik != null)
            {
                return 200;
            }
            else if (checkPhone != null) {
                return 300;
            }
            return insert;
        }

        public IEnumerable<RegisterVM> GetAllProfile() {
            
            var all = (from p in myContext.Persons
                               join a in myContext.Accounts on p.NIK equals a.NIK
                               join pr in myContext.Profilings on a.NIK equals pr.NIK
                               join e in myContext.Educations on pr.EducationId equals e.Id
                               join u in myContext.Universities on e.UniversityId equals u.Id
                               /*join ar in myContext.AccountRoles on a.NIK equals ar.AccountNIK
                               join r in myContext.AccountRoles on ar.RoleId equals r.RoleId*/
                               select new RegisterVM
                               {
                                   NIK = p.NIK,
                                   FirstName = p.FirstName,
                                   LastName = p.LastName,
                                   Phone = p.Phone,
                                   BirthDate = p.BirthDate,
                                   gender = (Gender)p.gender,
                                   Salary = p.Salary,
                                   Email = p.Email,
                                   //Password = a.Password,
                                   Degree = e.Degree,
                                   GPA = e.GPA,
                                   UniversityId = u.Id,
                                   AccountRoles = a.AccountRoles
                               }).ToList();
            return all;

        }

        public RegisterVM GetById(string nik)
        {
            var all = (from p in myContext.Persons
                       join a in myContext.Accounts on p.NIK equals a.NIK
                       join pr in myContext.Profilings on a.NIK equals pr.NIK
                       join e in myContext.Educations on pr.EducationId equals e.Id
                       join u in myContext.Universities on e.UniversityId equals u.Id
                       select new RegisterVM
                       {
                           NIK = p.NIK,
                           FirstName = p.FirstName,
                           LastName = p.LastName,
                           Phone = p.Phone,
                           BirthDate = p.BirthDate,
                           gender = (Gender)p.gender,
                           Salary = p.Salary,
                           Email = p.Email,
                           Password = a.Password,
                           Degree = e.Degree,
                           GPA = e.GPA,
                           UniversityId = e.UniversityId
                       }).ToList();
            return all.FirstOrDefault(p => p.NIK == nik);
        }
    }
}
