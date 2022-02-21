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
        $table->unsignedBigInteger('customer_id');
        $table->string('address');
        $table->string('status');
        $table->jsonb('options');
        $table->double('totaalprijs');
        $table->timestamps();

        $table->foreign('customer_id')->references('id')->on('users')->constrained();;
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
