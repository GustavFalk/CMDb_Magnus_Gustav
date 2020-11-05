//---------------------Read More/Read Less--------------------------//

readLess()

function readMore() {
    let text = document.getElementById("movie-plot");
    let readmorebtn = document.getElementById("readmore");
    let readlessbtn = document.getElementById("readless");
    text.style.overflow = "visible";
    text.style.webkitLineClamp = "1000";
    readmorebtn.style.display = "none";
    readlessbtn.style.display = "block";
}

function readLess() {
    let text = document.getElementById("movie-plot");
    let readmorebtn = document.getElementById("readmore");
    let readlessbtn = document.getElementById("readless");
    text.style.overflow = "hidden";
    text.style.webkitLineClamp = "3";
    readmorebtn.style.display = "block";
    readlessbtn.style.display = "none";
}

//---------------------Actor slide-----------------------//

var actorIndex = 0;
showActors();

function showActors() {
    var i;
    var actors = document.getElementsByClassName("myActors");
    for (i = 0; i < actors.length; i++) {
        actors[i].style.display = "none";
    }
    actorIndex++;
    if (actorIndex > actors.length) { actorIndex = 1 }
    actors[actorIndex - 1].style.display = "block";   

    setTimeout(showActors, 4000); 
}

//--------------------Like/Dislike--------------------//

let baseURL = "https://localhost:44313/api/movie/";

let imdbID = document.getElementById("imdb-id");

document.getElementById("like-btn").addEventListener("click", async function () {

    let response = await fetch(`${baseURL}${imdbID.value}/like`, { method: "GET", mode: "cors" });
    const data = await response.json();
    document.getElementById("numberoflikes").innerHTML = data.numberOfLikes;
    document.getElementById("numberofdislikes").innerHTML = data.numberOfDislikes;
    document.getElementById("like-btn").disabled = true;
    document.getElementById("dislike-btn").disabled = true;
   
  
    
   
});

document.getElementById("dislike-btn").addEventListener("click", async function () {

    let response = await fetch(`${baseURL}${imdbID.value}/dislike`, { method: "GET", mode: "cors" });
    const data = await response.json();
    document.getElementById("numberoflikes").innerHTML = data.numberOfLikes;
    document.getElementById("numberofdislikes").innerHTML = data.numberOfDislikes;
    document.getElementById("like-btn").disabled = true;
    document.getElementById("dislike-btn").disabled = true;

});