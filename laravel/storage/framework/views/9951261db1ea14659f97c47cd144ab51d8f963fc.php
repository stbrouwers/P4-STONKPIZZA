<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>STONKPIZZA</title>
        <link href="<?php echo e(asset('css/app.css')); ?>" rel="stylesheet">
        <script src="<?php echo e(asset('frameworks/jquery.js')); ?>"></script>
        <script src="<?php echo e(asset('js/vk.js')); ?>"></script>
        <style>
            body {
                background-color: rgb(8, 8, 8) !important;
            }
        </style>
    </head>
    <body onload="animfix()">
        <div id="homecontent" class="blur"></div>
        <div id="titlediv">
            <p class="DBD">ST<img id="titleimg" src="<?php echo e(asset('assets/Pizza-icon.png')); ?>" alt="">NKPIZZA</p>
        </div>
        <div id="homeselect">
            <div onclick="r('/dashboard')" id="killers" class="homenavbox anim in1">
                <img alt="killicon" src="<?php echo e(asset('assets/home.png')); ?>">
                <p>BESTELLEN</p>
            </div>
            <div onclick="r('/aanbod')" id="survivors" class="homenavbox anim in2">
                <img alt="survicon" class="fuckedimg" src="<?php echo e(asset('assets/list.png')); ?>">
                <p>AANBOD</p>
            </div>
            <div onclick="r('/dashboard')" id="perks" class="homenavbox anim in3">
                <img alt="survicon" class="fuckedimg2" src="<?php echo e(asset('assets/deliver.png')); ?>">
                <p>ORDER STATUS</p>
            </div>
        </div>
    </body>
</html><?php /**PATH D:\stonkpizza\balls\project4\resources\views/home.blade.php ENDPATH**/ ?>