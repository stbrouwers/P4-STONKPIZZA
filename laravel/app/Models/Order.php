<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Support\Facades\Auth;

class Order extends Model
{
    use HasFactory;
    protected $fillable = [
        'id','customer_id','address', 'status', 'options', 'totaalprijs',
    ];

    public function customer() {
        return $this->hasOne(Customer::class, 'customer_id');
    }
}
