<?php

namespace Database\Seeders;

use App\Models\Ingredient;
use Illuminate\Database\Seeder;

class IngredientSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $ingredients = [
            ['id' => 1, 'name' => 'Kaas', 'price' => 00.70],
            ['id' => 2, 'name' => 'Pepperoni', 'price' => 00.70],
            ['id' => 3, 'name' => 'Mozzarella', 'price' => 00.50],
            ['id' => 4, 'name' => 'Ui', 'price' => 00.40],
            ['id' => 5, 'name' => 'Emmentaler', 'price' => 00.90],
            ['id' => 6, 'name' => 'Champignon', 'price' => 00.60],
            ['id' => 7, 'name' => 'Ananas', 'price' => 00.60],
            ['id' => 8, 'name' => 'Ham', 'price' => 00.70],
            ['id' => 9, 'name' => 'Pepers', 'price' => 00.50],
        ];

        foreach ($ingredients as $ingredient) {
            Ingredient::create($ingredient);
        }
    }
}
