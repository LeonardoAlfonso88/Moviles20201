<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Categoria extends Model
{
    protected $table = 'categorias';
    protected $primaryKey = 'idCategoria';
    protected $fillable = ['idCategoria','categoria'];
    public $timestamps = false;

    public function productos()
    {
        return $this->hasMany('App\Models\Producto','idCategoria');
    }
}
