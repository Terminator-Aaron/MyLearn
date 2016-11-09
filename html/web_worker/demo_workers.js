var i=0;

/*function timedCount(){
    i++;
    postMessage(i);
    setTimeout("timedCount()", 500);
}

timedCount();
*/

setInterval(function(){
    i++;
    postMessage(i);
}, 500)