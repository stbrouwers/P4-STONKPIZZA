var order = [];
var currselected = {};
var tempitem = {};

var sizeindex = [
    "medium",
    "large",
    "extra large", 
]

var iteration = 0;
var sum = 0.00;
var check = false;
var previousid = 0;

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

    pricecalc("false") ;
    check = true;
}

function pricecalc(clicked) { 
    var amount = parseInt(document.getElementById('pamount').value);
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
    document.getElementById('options').value = JSON.stringify(order);
    document.getElementById('totaalprijs').value = ilovejs;
}

function orderDropdown(id, options, pizza) {
    if(id==previousid){return};
    var html = "";
    var order = JSON.parse(options);
    var pizzas = JSON.parse(pizza);
    var orderdiv = $("#order-"+id);
    var orderlist = $("#list-"+id);
    var anubtn = $('.status');
    var orderdestroy = 0;
    if($("#destroyform-"+id).length){var orderdestroy = $("#destroyform-"+id);}
    
    if(previousid!=0) {
        var previousdiv = $("#order-"+previousid);
        var previouslist = $("#list-"+previousid);

        if($("#destroyform-"+previousid).length){
            $("#destroyform-"+previousid).addClass('destroyform-dormant');
        }

        $(previousdiv).removeClass('expand');
        $(previousdiv).addClass('collapse');
        $(previouslist).html(html);
    }

    if($(orderdestroy).hasClass('destroyform-dormant') && orderdestroy != 0){
        $(orderdestroy).removeClass('destroyform-dormant');
    }
    previousid = id;

    if($(orderdiv).hasClass('collapse')){$(orderdiv).removeClass('collapse')};
    $(orderdiv).addClass('expand');

    for(let i in order) {
        var s = 0;
        var n = (order[i].item[0].pizzaid)-1;
        switch(order[i].item.size){case 0.80: s=0; break; case 1.00: s=1; break; case 1.20: s=2; break;};
    
        html += '<div class="itemdiv orderitemdiv"><p class="nnmout">'+pizzas[n].name+' x'+order[i].item[0].amount+'</p>';
        html += '<p>'+sizeindex[s]+'</p>';
        html += '<p>&euro;'+order[i].item[0].price+' ('+order[i].item[0].amount+'x &euro;'+(((order[i].item[0].price*order[i].item[0].size)/order[i].item[0].amount).toFixed(2))+')</p></div>';
    }
    $(orderlist).html(html);
    $(anubtn).value = "Geannuleerd";
}