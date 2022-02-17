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
                
                <div class="pizzaselect">
                    <div class="hoverdiv">
                        <p class="pizzasubtab" onclick="a2struct({{$pizza}})">+</p>
                        
                    </div>
                    <div class="imgcontainer"><img src="{{$pizza->imgurl}}" alt=""/></div>
                <p class="plistname">{{ $pizza->name }}</p>
                </div>
        </div>
    </form>
    @foreach($ingredients as $ingredient)
        
    @endforeach

    <div class="p-2 bg-gray-100 border-2 border-gray-200 rounded-sm w-2/6 float-right pinfocontainer">
        <h2 id="structname">test</h2>
            <input id="pamount" type="number" value="1">
            <select type="select" class="form-control sizeselect" id="sizeselector" name="sizes[]" multiple="">
                <option value="0.8">medium</option>
                <option value="1">large</option>
                <option value="1.2">extra large</option>
            </select>
            
            <x-button class="ml-3 bestelbutton" onclick="r('')">
                {{ __('toevoegen') }}
            </x-button>
    </div>

    <!-- Current order -->
    <form class="" method="POST" action="{{ route('order.store') }}">
        <div class="p-1 bg-gray-100 border-2 border-gray-200 rounded-sm h-96 w-2/6 float-right bestelsumcontainer">
            <div class="ordercontent">
                
            </div>

            <div class="orderstats">
                <div>
                    <br>
                    <p>order sum:</p>
                </div>

                <div>
                    <x-button class="ml-3 bestelbutton" onclick="r('')">
                        {{ __('bestellen') }}
                    </x-button>
                </div>
            </div>
        </div>
    </form>

</x-auth-card-app>
@endsection