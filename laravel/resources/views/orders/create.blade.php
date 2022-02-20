@extends('layouts.main')
@section('title')
    {{ __('Bestellen') }}
    <div class="hidden space-x-8 sm:-my-px sm:ml-10 sm:flex">
        <x-nav-link :href="route('order.create')" :active="request()->routeIs('order.create')">
            {{ __('Nieuwe bestelling') }}
        </x-nav-link>
        <x-nav-link :href="route('order.index')" :active="request()->routeIs('order.index')">
            {{ __('Mijn bestellingen') }}
        </x-nav-link>
    </div>
@endsection

@section('content')

<script>
    var submitted = false;
    var userinput = false;
    
    $(document).ready(function() {
    $("form").submit(function() {
        submitted = true;
    });
    
    $(".hiddeninp").change(function() {
        userinput = true;
        console.log('this worked!');
    });
    
    window.onbeforeunload = function () {
        if (userinput && !submitted) {
        return 'You do not have submitted the form yet.\
        Do you really want to leave this page?';
        }
    }
    });
</script>

<x-auth-card-app>
    <x-slot name="logo">
        <div class="flexrowdiv">
            <p class="navtitle">ST</p><img id="navimg" src="{{ asset('assets/Pizza-icon.png') }}" alt=""><p class="navtitle">NKPIZZA</p>
        </div>           
    </x-slot>
    <!-- Session Status -->
    <x-auth-session-status class="mb-4" :status="session('status')" />
    <!-- Validation Errors -->
    <x-auth-validation-errors class="mb-4" :errors="$errors" />

    <form class="orderform float-left">
        @csrf
        <div class="pizzacontainer">
                @foreach($pizzas as $pizza)
                    <div class="pizzaselect">
                        <div class="hoverdiv">
                            <p class="pizzasubtab" onclick="a2struct({{$pizza}}, {{$ingredients}})">+</p>
                            
                        </div>
                        <div class="imgcontainer"><img src="{{$pizza->imgurl}}" alt=""/></div>
                        <p class="plistname">{{ $pizza->name }}</p>
                    </div>
                @endforeach
        </div>
    </form>

    <div class="p-2 bg-gray-100 border-2 border-gray-200 rounded-sm w-2/6 float-right pinfocontainer">
        <h2 id="structname">customize</h2>
        <div id="structcontent">
            <select type="select" onchange="pricecalc('false')" class="form-control sizeselect structitem" id="sizeselector" name="sizes[]">
                <option value="0.8" selected>medium</option>
                <option value="1.0">large</option>
                <option value="1.2">extra large</option>
            </select>
            <input class="structitem" onchange="pricecalc('false')" id="pamount" type="number" value="1">
        </div>
        <div class="addsection">
            <p id="itemprice">0.00</p>
            <x-button class="ml-3 addbtn" onclick="pricecalc('true')">
                {{ __('toevoegen') }}
            </x-button>
        </div>
    </div>

    <!-- Current order -->
    <form class="" method="POST" action="{{ route('order.store') }}">
        @csrf
        <x-label for="options" class="hiddeninp" :value="__('options *')" />
        <x-input id="options" class="hiddeninp" type="text" name="options" :value="old('options')" required autofocus />
        <x-label for="totaalprijs" class="hiddeninp" :value="__('totaalprijs *')" />
        <x-input id="totaalprijs" class="hiddeninp" type="text" name="totaalprijs" :value="old('totaalprijs')" required autofocus />
        <div class="p-1 bg-gray-100 border-2 border-gray-200 rounded-sm h-72 w-2/6 float-right bestelsumcontainer">
            <div id="ordercontent"></div>
            <div class="orderstats">
                <div>
                    <p id="totaalprijsp">order sum: &euro;0.00</p>
                    <x-button class="ml-3 bestelbutton">
                        {{ __('bestellen') }}
                    </x-button>
                </div>
            </div>
        </div>
    </form>
</x-auth-card-app>
@endsection