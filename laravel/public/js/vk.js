var order = {"order": []};
var tempitem = {};

function r(l) {
    location.href = l;
}

function animfix() {
    setTimeout(function() {$("#killers").removeClass("in1"); $("#killers").addClass("animfix")},2600);
    setTimeout(function() {$("#survivors").removeClass("in2"); $("#survivors").addClass("animfix")},2800);
    setTimeout(function() {$("#perks").removeClass("in3"); $("#perks").addClass("animfix")},3000);
}

function a2struct(item) {
    document.getElementById('structname').textContent = item.name;

    console.log(item);
}

function a2order(id) {
    var tempitem = {
        "pizzaid": 10,
        "plusingredients": [1, 12],
        "miningredients": [4, 13],
        "size": "0.8", 
        "price": "9,30",
        "amount": 1,
    };
}





        /*
            {
                "order": [{
                        "pizzaid": 10,
                        "plusingredients": [1, 12],
                        "miningredients": [4, 13],
                        "size": "0.8", 
                        "price": "9,30";
                        "amount": 1,
                    },
                    {
                        "pizzaid": "0",
                        "plusingredients": [1, 12, 16, 71],
                        "miningredients": [],
                        "size": "1", 
                        "price": "5,90";
                        "amount": 3,
                    }
                    {
                        "pizzaid": "0",
                        "plusingredients": [1, 12, 16, 71],
                        "miningredients": [],
                        "size": "1.2", 
                        "price": "8";
                        "amount": 2,
                    }
                ]
            }
        */