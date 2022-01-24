function r(l) {
    location.href = l;
}

function animfix() {
    setTimeout(function() {$("#killers").removeClass("in1"); $("#killers").addClass("animfix")},2600);
    setTimeout(function() {$("#survivors").removeClass("in2"); $("#survivors").addClass("animfix")},2800);
    setTimeout(function() {$("#perks").removeClass("in3"); $("#perks").addClass("animfix")},3000);
}