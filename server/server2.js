const express = require("express");
const bodyParser = require("body-parser");
//!
const mysql = require("mysql");

let connection = mysql.createConnection({
  host: "localhost:3306",
  user: "root",
  password: "0000",
  database: "veritabani-adi",
});

connection.connect(function (err) {
  if (err) throw err;

  console.log("MySQL bağlantısı başarıyla gerçekleştirildi.");
});
//!
const app = express();
const port = 3000;

const jsonParser = bodyParser.json();

app.use(jsonParser);

app.get("/", (req, res) => {
  res.send("Hello World!");
});

app.post("/login", (req, res) => {
  const { username, password } = req.body;
  console.log(`username.length: ${username.length}`);
  console.log({
    username,
    password,
  });
  res.send({ message: "success" });
});

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`);
});
