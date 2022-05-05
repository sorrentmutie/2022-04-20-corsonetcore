const express = require("express");
const PORT = 8080;
const HOST = "0.0.0.0";

const app = express();

app.get("/", (request,response) => {
    response.send("Ciao, api");
});

app.listen(PORT,HOST);
console.log("Sono una API in esecuzione");