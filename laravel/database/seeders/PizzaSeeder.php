<?php

namespace Database\Seeders;

use App\Models\Pizza;
use Illuminate\Database\Seeder;

class PizzaSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        $pizzas = [
            ['id' => 1, 'name' => 'Pepperoni',  'iids' => "1 2 5 8", 'price' => 08.40, 'imgurl' => "https://www.pngall.com/wp-content/uploads/4/Pepperoni-Dominos-Pizza-PNG-Picture.png"],
            ['id' => 2, 'name' => 'Diavolo',  'iids' => "1 2 5 8 9", 'price' => 08.90, 'imgurl' => "https://www.pngmart.com/files/1/Pepperoni-Pizza-PNG-Transparent-Image.png"],
            ['id' => 3, 'name' => 'Mozzarella',  'iids' => "1 2 3 7", 'price' => 08.20, 'imgurl' => "https://www.pngall.com/wp-content/uploads/4/Dominos-Pizza-PNG-Pic.png"],
            ['id' => 4, 'name' => 'margherita',  'iids' => "1", 'price' => 07.50, 'imgurl' => "https://www.freepngimg.com/thumb/pizza/34411-4-cheese-pizza-clipart.png"],
        ]; 

        foreach ($pizzas as $pizza) {
            Pizza::create($pizza);
        }
    }
}
