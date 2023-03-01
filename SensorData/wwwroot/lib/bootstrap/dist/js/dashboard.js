/* globals Chart:false, feather:false */

(() => {
    'use strict'

    feather.replace({ 'aria-hidden': 'true' })

    // Graphs
    const ctx = document.getElementById('lineChart')
    // eslint-disable-next-line no-unused-vars
    const myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [
                '10:00',
                '10:30',
                '11:00',
                '11:30',
                '12:00',
                '12:30',
                '13:00'
            ],
            datasets: [{
                data: [
                    0.893,
                    0.894,
                    0.899,
                    0.896,
                    0.905,
                    0.901,
                    0.918
                ],
                lineTension: 0,
                backgroundColor: 'transparent',
                borderColor: '#007bff',
                borderWidth: 4,
                pointBackgroundColor: '#008bff'
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: false
                    }
                }]
            },
            legend: {
                display: false
            }
        }
    })
})()
