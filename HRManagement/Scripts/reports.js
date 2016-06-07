$(function () {
    $.ajax({
        url: "/api/reports/population",
        method: "GET"
    }).success(function (data) {

        for (var i = 1; i <= 2; i++) {
            $('#chart' + i).highcharts({
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Monthly Average Rainfall'
                },
                subtitle: {
                    text: 'Source: WorldClimate.com'
                },
                xAxis: {
                    categories: [
                        'Jan',
                        'Feb',
                        'Mar',
                        'Apr',
                        'May',
                        'Jun',
                        'Jul',
                        'Aug',
                        'Sep',
                        'Oct',
                        'Nov',
                        'Dec'
                    ],
                    crosshair: true
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Rainfall (mm)'
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                }
            });
            for (var item = 0 ; item< data.length;item++) {
                $('#chart' + i).highcharts().addSeries({ name: data[item].City, data: data[item].PopulationPerMonth }, false);
            }
            $('#chart' + i).highcharts().redraw();
        }

    });

    $.ajax({
        url: "/api/reports/population2",
        method: "GET"
    }).success(function (data) {
        for (var i = 3; i <= 4; i++) {
            $('#chart' + i).highcharts({
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Employees grouped by age'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },

            });

            var formattedDate = [];

            for (var item = 0 ; item < data.length; item++) {
                formattedDate.push({ name: data[item].Description, y: data[item].Values });
            }

            $('#chart' + i).highcharts().addSeries({ name: "Age", colorByPoint: true , data : formattedDate});

            $('#chart' + i).highcharts().redraw();  
        }
    });

});