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

    <form class="orderform w-4/6" method="POST" action="{{ route('order.store') }}">
        @csrf
        <div>
            <select class="form-control" name="pizzas[]" multiple="">
                @foreach($pizzas as $pizza)
                    <option value="{{ $pizza->id }}">{{ $pizza->name }}</option>
                @endforeach
            </select>
        </div>

    </form>

    <!-- Current order -->
    <div class="p-6 bg-gray-100 border-2 border-gray-200 rounded-sm h-96 w-2/6 float-right bestelsumcontainer">
        <div class="ordercontent">
            
        </div>

        <div class="orderstats">
            <div>
                <p>order contents:</p>
                <p>order sum:</p>
            </div>

            <div>
                <x-button class="ml-3 bestelbutton" onclick="r('/register')">
                    {{ __('bestellen') }}
                </x-button>
            </div>
        </div>
    </div>

</x-auth-card-app>
@endsection