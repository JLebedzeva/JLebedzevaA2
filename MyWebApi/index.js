/*
  Julia Lebedzeva
  Assignment 3
  8658087
  11/18/2024
*/

const express = require('express');
const sqlite = require('sqlite');
const sqlite3 = require('sqlite3');
const path = require('path');
const app = express(); 
module.exports = app;
const HTTP_PORT = process.env.PORT || 8080;

app.use(express.json());

let db = new sqlite3.Database("./greetings.db", (err) => {
  if (err) {
      console.error("Error opening the database" + err.message);
  }
  else {
      console.log("Connection to the database is working!");
  }
});

app.post('/api/greet', (req, res) => {
  
  const {TimeOfDay, Language, Tone} = req.body;

  if (!TimeOfDay || !Language){
    return res.status(400).send("Must have a time of day and language.");
  }
  const query = "SELECT GreetingMessage FROM Greetings WHERE TimeOfDay = ? AND Language = ? AND Tone = ?";

  db.get(query, [TimeOfDay, Language, Tone || "Formal"], (err, row) => {
    if (err){
      return res.status(500).send(err.message);
    }
    if (!row){
      return res.status(404).send("Sorry no greeting found");
    }
    let response = {GreetingMessage: row.GreetingMessage};
    res.json(response);
  });

});
  
app.get('/api/greet', (req, res) => {
  
  const {TimeOfDay, Language, Tone} = req.body;

  if (!TimeOfDay || !Language){
    return res.status(400).send("Must have a time of day and language.");
  }
  const query = "SELECT GreetingMessage FROM Greetings WHERE TimeOfDay = ? AND Language = ? AND Tone = ?";

  db.get(query, [TimeOfDay, Language, Tone || "Formal"], (err, row) => {
    if (err){
      return res.status(500).send(err.message);
    }
    if (!row){
      return res.status(404).send("Sorry no greeting found");
    }
    let response = {GreetingMessage: row.GreetingMessage};
    res.json(response);
  });

});


app.get('/api/getAllTimesOfDay', async (req, res) => {
  db.all("SELECT DISTINCT TimeOfDay FROM greetings", [], (err, rows) => {
    if (err) {
      console.error("Error query ", err.message);
      res.status(500).send(err.message);
    }
    else {
      console.log("Raw data ", rows);
      res.json(rows.map((row) => row.TimeOfDay));
    }
  });
});

  
app.get('/api/getSupportedLanguages', async (req, res) => {
  db.all("SELECT DISTINCT Language FROM greetings", [], (err, rows) => {
    if (err) {
      console.error("Error query ", err.message);
      res.status(500).send(err.message);
    }
    else {
      console.log("Raw data ", rows);
      res.json(rows.map((row) => row.Language));
    }
  });
});


app.listen(HTTP_PORT, () => console.log(`Server listening on: ${HTTP_PORT}`));


