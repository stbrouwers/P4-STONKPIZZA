@extends('layouts.main')
@section('title')
    {{ __('Dashboard') }}
@endsection

@section('content')
    <h1 id="DashTitle">Welkom {{ Auth::user()->name }}!</h1>
@endsection
