<?php

namespace App\Http\Controllers;

use App\Models\Order;
use App\Models\Pizza;
use App\Models\Ingredient;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;


class OrderController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */

    public function index()
    {
        $pizzas = Pizza::all();
        $ingredients = Ingredient::all();
        $orders = Order::where('customer_id', Auth::id())->orderBy('created_at', 'DESC')->get();
        return view('orders.index', ['pizzas' => $pizzas, 'ingredients' => $ingredients, 'orders' => $orders]);
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        $pizzas = Pizza::all();
        $ingredients = Ingredient::all();
        $url = \URL::full();
        return view('orders.create', ['pizzas' => $pizzas, 'ingredients' => $ingredients, 'currurl' => $url]);
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
        $order = new Order();
        $order->customer_id = Auth::id();
        $order->address = 'test adres';
        $order->status = 'In de wachtrij';
        $order->options = $request->options;
        $order->totaalprijs = $request->totaalprijs;
        $order->save();

        return redirect()->route('order.index');
    }

    /**
     * Display the specified resource.
     *
     * @param  \App\Models\Bestellen  $bestellen
     * @return \Illuminate\Http\Response
     */
    public function show(Order $order)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  \App\Models\Bestellen  $bestellen
     * @return \Illuminate\Http\Response
     */
    public function edit(Order $order)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \App\Models\Bestellen  $bestellen
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, Order $order)
    {
        $data = Order::find($order->id);
        $data->status = $request->status;
        $data->save();
        
        return redirect()->route('order.index');
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  \App\Models\Bestellen  $bestellen
     * @return \Illuminate\Http\Response
     */
    public function destroy(Order $order)
    {
        //
    }
}
