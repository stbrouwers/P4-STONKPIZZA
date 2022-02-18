var order = [];

var currselected = {};
var tempitem = {};
var iteration = 0;
var sum = 0.00;
var check = false

function r(l) {
    location.href = l;
}

function animfix() {
    setTimeout(function() {$("#killers").removeClass("in1"); $("#killers").addClass("animfix")},2600);
    setTimeout(function() {$("#survivors").removeClass("in2"); $("#survivors").addClass("animfix")},2800);
    setTimeout(function() {$("#perks").removeClass("in3"); $("#perks").addClass("animfix")},3000);
}

function a2struct(item) {
    currselected = item;
    document.getElementById('structname').textContent = item.name;

    console.log(item);
    pricecalc("false") ;
    check = true;
}

function pricecalc(clicked) { 
    var amount =  parseInt(document.getElementById('pamount').value);
    var stringsize = (document.getElementById('sizeselector').value).toString();
    var size = parseFloat(stringsize);
    var price = currselected.price;
    var actualprice = ((price*size)*amount).toFixed(2);

    document.getElementById('itemprice').textContent = "€"+actualprice;

    if(clicked=="true"){a2order(amount, size, actualprice)}
}

function a2order(amount, size, price) {
    if(!check){return};
    tempitem = {
        item: [{
            "pizzaid": currselected.id,
            "plusingredients": [],
            "miningredients": [],
            "size": size, 
            "price": price,
            "amount": amount,
        }]
    };
    order.splice(iteration, 0, tempitem);
    iteration++;
    parsedprice = parseFloat(price);
    sum = (sum + parsedprice);
    ilovejs = sum.toFixed(2);

    var html = '<div class="itemdiv"><p class="nnmout">'+currselected.name +' x'+amount+'</p>';
    html += '<p>'+$("#sizeselector option:selected").text()+'</p>';
    html+= '<p>&euro;'+price+' ('+amount+'x &euro;'+((currselected.price*size).toFixed(2))+')</p></div>';
    document.getElementById("ordercontent").innerHTML += html;
    document.getElementById("totaalprijsp").textContent = "order sum: €" + ilovejs;
    console.log(order + "it" + iteration);
    document.getElementById('options').value = JSON.stringify(order);
    document.getElementById('totaalprijs').value = ilovejs;

}

function submitorder() {

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