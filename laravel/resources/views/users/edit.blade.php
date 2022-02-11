@extends('layouts.main')
@section('title')
    {{ __('Wijzig een user/gebruiker:') }}
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

        <form method="POST" action="{{ route('user.update', [$user]) }}">
            @csrf
            @method('put')
            <div>
                <x-label for="name" :value="__('naam')" />
                <x-input id="name" class="block mt-1 w-full" type="text" name="name" value="{{ $user->name }}" required autofocus />
            </div>

            <div class="flex items-center justify-end mt-4">
                <x-button class="ml-3">
                    {{ __('Bewaar') }}
                </x-button>
            </div>
        </form>
    </x-auth-card-app>
@endsection
