const express = require('express');
const sqlite = require('sqlite');
const sqlite3 = require('sqlite3');
const path = require('path');
const app = express(); 


let db = new sqlite3.Database("./greetings.db", (err) => {
    if (err) {
        console.error("Error opening the database" + err.message);
    }
    else {
        console.log("Connection to the database is working!");
    }
});

module.exports = db;
