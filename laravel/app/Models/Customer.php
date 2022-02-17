<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Customer extends Model
{
    use HasFactory;

    protected $guarded = [
        'id', 'first_name', 'last_name', 'address', 'phone', 'zipcode', 'city', 'pizza_points',
    ];
}
