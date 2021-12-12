let connection = new signalR.HubConnectionBuilder()
    .withUrl("/temperature")
    .build();

connection.on("update_temperature", data => {
    updateGraph(data.fahrenheit, data.celcius);
});

connection.start().then(() => {});
createPlot();

function createPlot() {
    var f = {
        y: [], 
        type: 'scatter',
        name:'Fahrenheit'
    };
        
    var c = {
        y: [], 
        type: 'scatter',
        'name':'Celcius'
    };
        
    var data = [f,c];

    var layout = {
        title: {
          text:'Temperature Data in my Basement',
          font: {
            family: 'Courier New, monospace',
            size: 24
          },
          xref: 'paper',
          x: 0.05,
        },
        xaxis: {
          title: {
            text: 'Time (Seconds)',
            font: {
              family: 'Courier New, monospace',
              size: 18,
              color: '#7f7f7f'
            }
          },
        },
        yaxis: {
          title: {
            text: 'Temperature',
            font: {
              family: 'Courier New, monospace',
              size: 18,
              color: '#7f7f7f'
            }
          }
        }
      };
      /*
    Plotly.newPlot(document.getElementById("temperature"),[{
        y: [],
        type:'line'
    }], layout);
    */
   Plotly.newPlot(document.getElementById("temperature"),data, layout);

}

function updateGraph(f,c){

    Plotly.extendTraces(document.getElementById("temperature"), { y: [[f],[c]] }, [0,1])
}