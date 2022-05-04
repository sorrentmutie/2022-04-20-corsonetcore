window.miaPrimaFunzione = function (argomento) {
    console.log(argomento);
    return 1;
}

window.miaSecondaFunzione = (argomento) => {
    console.log(argomento);
    return 2;
}

window.miaTerzaFunzione = (a, b) => a + b;

window.miaQuartaFunzione = (argomento) => {
    console.log(argomento);
    DotNet.invokeMethodAsync("BlazorHttpApi", "RestituisciArrayAsync")
        .then(dati => console.log(dati));
}

window.miaQuintaFunzione = (oggetto) => {
    oggetto.invokeMethodAsync('SayHello')
        .then(r => console.log(r));
}

let myModal;
window.apriModale = (id) => {
    myModal = new bootstrap.Modal(document.getElementById(id));
    myModal.show();
}

window.chiudiModale = () => {
    if (myModal) {
        myModal.hide();
    }
}

window.creaChart = (id, width, height, data) => {

    var dataPlotted = {
        labels: data.labels,
        series: []
    }

    data.series.forEach(x => dataPlotted.series.push(x.values));


    //var data = {
    //    // A labels array that can contain any sort of values
    //    labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
    //    // Our series array that contains series objects or in this case series data arrays
    //    series: [
    //        [5, 2, 4, 2, 0]
    //    ]
    //};

    console.log(data);

    var options = {
        width: width,
        height: height
    };

    new Chartist.Line('#' + id, dataPlotted, options);
}

window.creaBarChart = (id, width, height, data) => {
    //var data = {
    //    // A labels array that can contain any sort of values
    //    labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
    //    // Our series array that contains series objects or in this case series data arrays
    //    series: [
    //        [5, 2, 4, 2, 0]
    //    ]
    //};


    var dataPlotted = {
        labels: data.labels,
        series: []
    }

    data.series.forEach(x => dataPlotted.series.push(x.values));


    var options = {
        width: width,
        height: height
    };

    new Chartist.Bar('#' + id, dataPlotted, options);
}