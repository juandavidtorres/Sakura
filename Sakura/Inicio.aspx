<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="Inicio.aspx.vb" Inherits="Sakura.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="Server">
    <h5>Dashboard</h5>
    <p>Mire el crecimiento de la iglesia </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var chartData;
        var chart;
        AmCharts.ready(function () {
            chartData = '<%=RecuperarListaAsistencia()%>';
            chartData = $.parseJSON(chartData);
            // SERIAL CHART
            chart = new AmCharts.AmSerialChart(AmCharts.themes.light);
            chart.dataProvider = chartData;
            chart.categoryField = "Mes";
            chart.startDuration = 1;

            // AXES
            // category
            var categoryAxis = chart.categoryAxis;
            categoryAxis.labelRotation = 90;
            categoryAxis.gridPosition = "start";

            // value
            // in case you don't want to change default settings of value axis,
            // you don't need to create it, as one value axis is created automatically.

            // GRAPH
            var graph = new AmCharts.AmGraph();
            graph.valueField = "Cantidad";
            graph.balloonText = "[[category]]: <b>[[value]]</b>";
            graph.type = "column";
            graph.lineAlpha = 0;
            graph.fillAlphas = 0.8;
            chart.addGraph(graph);

            // CURSOR
            var chartCursor = new AmCharts.ChartCursor();
            chartCursor.cursorAlpha = 0;
            chartCursor.zoomable = false;
            chartCursor.categoryBalloonEnabled = false;
            chart.addChartCursor(chartCursor);

            chart.creditsPosition = "top-right";

            chart.write("chartdiv");
        });
    </script>


    <script type="text/javascript">
        var chartPie;

        var chartDataPie = '<%=RecuperarDistribuccionServicio(1, -3)%>';
        chartDataPie = $.parseJSON(chartDataPie);
        AmCharts.ready(function () {
            // PIE CHART
            chartPie = new AmCharts.AmPieChart();

            // LEGEND
            legend = new AmCharts.AmLegend();
            legend.align = "center";
            legend.markerType = "circle";
            chartPie.balloonText = "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>";
            chartPie.addLegend(legend);

            // title of the chart
            chartPie.addTitle("Distribucion trimestral dominical", 16);
            chartPie.dataProvider = chartDataPie;
            chartPie.titleField = "Servicio";
            chartPie.valueField = "Porcentaje";
            chartPie.sequencedAnimation = true;
            chartPie.startEffect = "elastic";
            chartPie.innerRadius = "20%";
            chartPie.startDuration = 2;
            chartPie.labelRadius = 15;
            chartPie.balloonText = "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>";
            // the following two lines makes the chart 3D
            chartPie.depth3D = 10;
            chartPie.angle = 15;


            chartPie.autoMargins = false;
            chartPie.marginTop = 0;
            chartPie.marginBottom = 0;
            chartPie.marginLeft = 0;
            chartPie.marginRight = 0;
            chartPie.pullOutRadius = 0

            // WRITE                                 
            chartPie.write("chartdivPieDominical");

        });
        function setLabelPosition() {
            chartPie.validateNow();
        }
    </script>

    <script type="text/javascript">
        var chartPieSanidad;
        var chartDataPieSanidad = null;
        chartDataPieSanidad = '<%=RecuperarDistribuccionServicio(2, -3)%>';
        chartDataPieSanidad = $.parseJSON(chartDataPieSanidad);

        AmCharts.ready(function () {
            // PIE CHART
            chartPieSanidad = new AmCharts.AmPieChart();

            // LEGEND
            legend = new AmCharts.AmLegend();
            legend.align = "center";
            legend.markerType = "circle";
            chartPieSanidad.balloonText = "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>";
            chartPieSanidad.addLegend(legend);

            // title of the chart
            chartPieSanidad.addTitle("Distribucion trimestral jueves", 16);
            chartPieSanidad.dataProvider = chartDataPieSanidad;
            chartPieSanidad.titleField = "Servicio";
            chartPieSanidad.valueField = "Porcentaje";
            chartPieSanidad.sequencedAnimation = true;
            chartPieSanidad.startEffect = "elastic";
            chartPieSanidad.innerRadius = "20%";
            chartPieSanidad.startDuration = 2;
            chartPieSanidad.labelRadius = 15;
            chartPieSanidad.balloonText = "[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>";
            // the following two lines makes the chart 3D
            chartPieSanidad.depth3D = 10;
            chartPieSanidad.angle = 15;


            chartPieSanidad.autoMargins = false;
            chartPieSanidad.marginTop = 0;
            chartPieSanidad.marginBottom = 0;
            chartPieSanidad.marginLeft = 0;
            chartPieSanidad.marginRight = 0;
            chartPieSanidad.pullOutRadius = 0

            // WRITE                                 
            chartPieSanidad.write("chartdivPieSanidad");

        });

        function setLabelPosition() {
           
            chartPieSanidad.validateNow();
        }

    </script>
    <div class="row">
     
            <div class="form-group">
                <ul class="page-stats list-justified">
                    <li class="bg-info">
                        <div class="page-stats-showcase">
                            <span>Asistentes adultos del mes <%= Fabrica.Utilidades.MesActual()%>  </span>
                            <h2><%= RecuperarTotalAsistentes()%></h2>
                        </div>
                        <div class="bar-default chart">10,14,8,45,23,41,22,31,19,12, 28, 21, 24, 20</div>
                    </li>
                    <li class="bg-success">
                        <div class="page-stats-showcase">
                            <span>Total vehiculos del mes <%= Fabrica.Utilidades.MesActual()%></span>
                            <h2><%=RecuperarTotalVehiculos()%></h2>
                        </div>
                        <div class="bar-default chart">10,14,8,45,23,41,22,31,19,12, 28, 21, 24, 20</div>
                    </li>
                    <li class="bg-danger">
                        <div class="page-stats-showcase">
                            <span>Promedio asistencia dominical <%= Fabrica.Utilidades.MesActual()%> </span>
                            <h2><%=RecuperarPromedioDominical()%></h2>
                        </div>
                        <div class="bar-default chart">10,14,8,45,23,41,22,31,19,12, 28, 21, 24, 20</div>
                    </li>
                    <li class="bg-success">
                        <div class="page-stats-showcase">
                            <span>Promedio asistencia jueves <%= Fabrica.Utilidades.MesActual()%> </span>
                            <h2><%=RecuperarPromedioSanidad()%></h2>
                        </div>
                        <div class="bar-default chart">10,14,8,45,23,41,22,31,19,12, 28, 21, 24, 20</div>
                    </li>
                    <li class="bg-warning">
                        <div class="page-stats-showcase">
                            <span>Asistentes niños del mes <%= Fabrica.Utilidades.MesActual()%> </span>
                            <h2><%=RecuperarTotalInfantes()%></h2>
                        </div>
                        <div class="bar-default chart">10,14,8,45,23,41,22,31,19,12, 28, 21, 24, 20</div>
                    </li>
                </ul>
            </div>
        </div>
  

    <div class="row">
        <div class="panel panel-info">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-dashboard"></i>Asistencia de los ultimos 12 meses</h6>
            </div>
            <div class="panel-body">
                <div id="chartdiv" style="width: 100%; height: 400px;"></div>
            </div>
        </div>
    </div>



    <div class="row">
        <div class="panel panel-warning">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-dashboard"></i>Distribucion trimestral de servicio  dominical</h6>
            </div>
            <div class="panel-body">
                <div id="chartdivPieDominical" style="width: 600px; height: 400px;"></div>

            </div>
        </div>
    </div>

    <div class="row">
        <div class="panel panel-warning">
            <div class="panel-heading">
                <h6 class="panel-title"><i class="icon-dashboard"></i>Distribucion trimestral de servicio  sanidad</h6>
            </div>
            <div class="panel-body">
                <div id="chartdivPieSanidad" style="width: 600px; height: 400px;"></div>
            </div>
        </div>
    </div>



</asp:Content>

