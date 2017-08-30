var dataForChart;

$('#resForm').submit(function (event) {
    event.preventDefault();
    var $form = $(this),
        url = $form.attr('action');

    var jqxhr = $.post(url, $('#resForm').serialize(),
        function (jsonData) {
            console.log(jsonData);
            dataForChart = jsonData;
            drawChart();
        });
});

google.charts.load('current', { 'packages': ['corechart', 'line'] });

function drawChart() {
    var data = new google.visualization.DataTable();
    data.addColumn('number', 'X');
    data.addColumn('number', 'Y');

    for (var i = 0; i < dataForChart.length; i++) {
        data.addRow([dataForChart[i].PointX, dataForChart[i].PointY]);
    }

    var options = {
        title: 'The Porabolic function',
        curveType: 'function',
        legend: { position: 'right' },
        hAxis: {
            title: 'X'
        },
        vAxis: {
            title: 'Y'
        }
    };

    var chart = new google.visualization.LineChart(document.getElementById('image'));

    chart.draw(data, options);
}