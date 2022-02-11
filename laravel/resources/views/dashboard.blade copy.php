<x-app-layout>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>layout</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link href="{{ asset('css/app.css') }}" rel="stylesheet">
        <script src="{{ asset('js/vk.js') }}"></script>
    </head>
    <body>
        <ul id='navul'>
            <li onclick="r('/bestellen')" class="navitem navselected"><p>bestellen</p></li>
            <li onclick="r('/aanbod')" class="navitem "><p>aanbod</p></li>
            <li onclick="r('/order')" class="navitem "><p>order status</p></li>
        </ul>
        
        <div id="homecontent">
            <div id="content">
                <div id="contentcontainer">
                    @yield('content')
                </div>
            </div>
        </div>
    </body>
</html>
</x-app-layout>
