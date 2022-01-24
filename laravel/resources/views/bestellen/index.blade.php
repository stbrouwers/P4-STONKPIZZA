@extends('bestellen.layout')
@section('content')
<form action="{{ route('articles.store') }}" method="POST">
@csrf
  <div class="form-group">
    <label for="topic">Name title</label>
    <input type="text" class="form-control"  placeholder="Enter Topic" name ="name">
  </div>
  <div class="form-group">
    <label for="description">Description</label>
    <textarea class="form-control" rows="3"placeholer ="Enter description" name="description"></textarea>
  </div>
  <div class="form-group">
    <label for="categorie">Type</label>
    <input type="text" class="form-control"  placeholder="Enter Categorie" name="type">
  </div>
  <button type="submit" class="btn btn-primary">Submit</button>
</form>
@endsection