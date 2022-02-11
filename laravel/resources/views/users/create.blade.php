@extends('layouts.main')
@section('title')
    {{ __('Maak een user/gebruiker:') }}
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

        <form method="POST" action="{{ route('user.store') }}">
            @csrf
            <div>
                <x-label for="name" :value="__('name')" />
                <x-input id="name" class="block mt-1 w-full" type="text" name="name" :value="old('name')" required autofocus />
            </div>
            <div>
                <x-label for="email" :value="__('email')" />
                <x-input id="email" class="block mt-1 w-full" type="email" name="email" :value="old('email')" required autofocus />
            </div>

            <div>
                <x-label for="password" :value="__('password')" />
                <x-input id="password" class="block mt-1 w-full" type="password" name="password" :value="old('password')" required autofocus />
            </div>

            <div class="flex items-center justify-end mt-4">
                <x-button class="ml-3">
                    {{ __('Bewaar') }}
                </x-button>
            </div>
        </form>
    </x-auth-card-app>
@endsection
