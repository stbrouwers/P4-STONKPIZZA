<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>STONKPIZZA</title>
        <link href="{{ asset('css/app.css') }}" rel="stylesheet">
        <script src="{{ asset('frameworks/jquery.js') }}"></script>
        <script src="{{ asset('js/vk.js') }}"></script>
        <style>
            body {
                background-color: rgb(8, 8, 8) !important;
            }
        </style>
    </head>
    <body onload="animfix()">
        <div id="homecontent" class="blur"></div>
        <div id="titlediv">
            <p class="DBD">ST<img id="titleimg" src="{{ asset('assets/Pizza-icon.png') }}" alt="">NKPIZZA</p>
        </div>
        <div id="homeselect">
            <div onclick="r('/bestellen')" id="killers" class="homenavbox anim in1">
                <img alt="killicon" src="{{ asset('assets/home.png') }}">
                <p>BESTELLEN</p>
            </div>
            <div onclick="r('/aanbod')" id="survivors" class="homenavbox anim in2">
                <img alt="survicon" class="fuckedimg" src="{{ asset('assets/list.png') }}">
                <p>AANBOD</p>
            </div>
            <div onclick="r('/order')" id="perks" class="homenavbox anim in3">
                <img alt="survicon" class="fuckedimg2" src="{{ asset('assets/deliver.png') }}">
                <p>ORDER STATUS</p>
            </div>
        </div>
    </body>
</html>