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

@endsection