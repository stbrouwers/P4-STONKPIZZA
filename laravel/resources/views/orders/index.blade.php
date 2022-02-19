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
    <div class="orderhistory">
    @foreach($orders as $order)
        <div onclick="orderDropdown({{$order->id}}, '{{$order->options}}', '{{$pizzas}}')" id="order-{{$order->id}}" class="order">
            <div class="leftordergroup">
                @if($order->status == "In de wachtrij")
                    <span style="font-size: 20px;">🕒</span>
                @elseif($order->status == "Geannuleerd")
                    <span style="background-color: rgb(255, 43, 43);" class="statusdot"></span>
                @elseif($order->status == "Word bereid")
                    <span style="font-size: 20px;">⁖</span>
                @elseif($order->status == "In de oven")
                    <span style="font-size: 20px;">♨️</span>
                @elseif($order->status == "Onderweg")
                    <span style="font-size: 20px;">🚚</span>
                @else
                    <span style="background-color: rgb(0, 255, 0);" class="statusdot"></span>
                @endif
                <h1 class="orderid">#{{$order->id}}</h1>
            </div>
            <div class="middleordergroup">
                <div id="list-{{$order->id}}" class="itemlist">
                    
                </div>
            </div>
            <div class="rightordergroup">
                <h1 class="ordercdate">{{$order->created_at}}</h1>
                <h1 class="orderstatus">status: {{$order->status}}</h1>
                <h1>totaal: &euro;{{$order->totaalprijs}}</h1> 
                @if($order->status == "In de wachtrij" || $order->status == "Word bereid")
                    <form id="destroyform-{{$order->id}}" class="destroyform destroyform-dormant" action="{{ route('order.update', [$order]) }}" method="post">
                        @csrf
                        @method('put')
                        <x-label for="status-{{$order->id}}" class="hiddeninp" :value="__('status')"/>
                        <x-input id="status-{{$order->id}}" class="hiddeninp status" type="hidden" name="status" :value="('Geannuleerd')" required autofocus />
                        <div>
                            <x-button class="ml-3 bg-red-500 w-32">
                                {{ __('Annuleren') }}
                            </x-button>
                        </div>
                    </form>
                @endif
            </div>
        </div>
    @endforeach
    </div>
@endsection