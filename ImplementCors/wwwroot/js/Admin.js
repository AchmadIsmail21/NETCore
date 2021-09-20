
$(document).ready(function () {
    $.ajax({
        url: `https://localhost:44316/api/Persons/GetAllProfile`,
        type: "GET"
    }).done((result) => {
        console.log(result);
        var female = result.filter(data => data.gender === 1).length;
        var male = result.filter(data => data.gender === 0).length;
        
        console.log(male);
        
        var options = {
            series: [male, female],
            chart: {
                type: 'pie',
            },
            labels: ['Male', 'Female'],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
        };
        var chart = new ApexCharts(document.querySelector("#PersonCh"), options);
        chart.render();
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Deleted',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    });
});

$(document).ready(function () {
    $.ajax({
        url: `https://localhost:44316/api/Persons/GetAllProfile`,
        type: "GET"
    }).done((result) => {
        console.log(result);
        var harvard = result.filter(data => data.universityId === 3).length;
        var oxford = result.filter(data => data.universityId === 4).length;
        console.log(harvard);
        console.log(oxford);

        var options = {
            series: [harvard, oxford],
            chart: {
                type: 'donut',
            },
            labels: ['Harvard', 'Oxford'],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
        };
        
        var chart = new ApexCharts(document.querySelector("#UnivCh"), options);
        chart.render();
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Deleted',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    });
});

$(document).ready(function () {
    $.ajax({
        url: `https://localhost:44316/api/Persons/GetAllProfile`,
        type: "GET"
    }).done((result) => {
        console.log(result);
        var female = result.filter(data => data.gender === 1).length;

        var salary = result.filter(data => data.salary > 1500000).length;
        var salary2 = result.filter(data => data.salary < 5500000).length;

        var options = {
            series: [{
                data: [male, female]
            }],
            chart: {
                height: 350,
                type: 'bar',
            },
            plotOptions: {
                bar: {
                    borderRadius: 10,
                    dataLabels: {
                        position: 'top', // top, center, bottom
                    },
                }
            },
            dataLabels: {
                enabled: true,
                formatter: function (val) {
                    return val + "%";
                },
                offsetY: -20,
                style: {
                    fontSize: '12px',
                    colors: ["#304758"]
                }
            },
            xaxis: {
                categories: ["Male", "Female"],
                position: 'top',
                axisBorder: {
                    show: false
                },
                axisTicks: {
                    show: false
                },
                crosshairs: {
                    fill: {
                        type: 'gradient',
                        gradient: {
                            colorFrom: '#D8E3F0',
                            colorTo: '#BED1E6',
                            stops: [0, 100],
                            opacityFrom: 0.4,
                            opacityTo: 0.5,
                        }
                    }
                },
                tooltip: {
                    enabled: true,
                }
            },
            yaxis: {
                axisBorder: {
                    show: false
                },
                axisTicks: {
                    show: false,
                },
                labels: {
                    show: false,
                    formatter: function (val) {
                        return val + "%";
                    }
                }
            }
        };
        var chart = new ApexCharts(document.querySelector("#PersonCh"), options);
        chart.render();
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Deleted',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    });
});
