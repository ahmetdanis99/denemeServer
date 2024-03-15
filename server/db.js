const mongoose = require("mongoose");

const db = () => {
  mongoose
    .connect(
      "mongodb+srv://ahmet:Cv0nccTLGkT6Jska@cluster0.p8m2laz.mongodb.net/unity?retryWrites=true&w=majority"
    )
    .then(() => {
      console.log("mongoDB connected!!!");
    })
    .catch((err) => {
      console.log("booom" + err);
    });
};
module.exports = db;