<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class BestellingenTable extends Migration
{
    /**
     * Run the migrations.
     *  
     * @return void
     */
    public function up()
    {
        Schema::create('Orders', function (Blueprint $table) {
        $table->id();
        $table->foreign('customer_id')->references('id')->on('users');
        $table->string('address');
        $table->string('status');
        $table->jsonb('options');
        /*
            {
                "order": [{
                        "pizzaid": 10,
                        "plusingredients": [1, 12],
                        "miningredients": [4, 13],
                        "size": "0.8", 
                        "price": "9,30";
                        "amount": 1,
                    },
                    {
                        "pizzaid": "0",
                        "plusingredients": [1, 12, 16, 71],
                        "miningredients": [],
                        "size": "1", 
                        "price": "5,90";
                        "amount": 3,
                    }
                    {
                        "pizzaid": "0",
                        "plusingredients": [1, 12, 16, 71],
                        "miningredients": [],
                        "size": "1.2", 
                        "price": "8";
                        "amount": 2,
                    }
                ]
            }
        */
        $table->double('totaalprijs');
        $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('Orders');
    }
}
