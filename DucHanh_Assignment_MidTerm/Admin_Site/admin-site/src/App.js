import "bootstrap/dist/css/bootstrap.min.css";
import NavbarComp from "./Components/NavbarComp";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import Category from "./Category/Category";
import Product from "./Product/Product";
import AddCategory from "./Category/AddCategory";
import EditCategory from "./Category/EditCategory";
import DeleteCategory from "./Category/DeleteCategory";

function App() {
  return (
    <div className="App">
      <Router>
        <NavbarComp />
        <Routes>
          {/* Add router for navbar */}
          <Route path="/" element={<Category />}></Route>
          <Route path="/Product" element={<Product />}></Route>
           {/* Add router for category */}
          <Route path='/AddCategory' element={<AddCategory/>}></Route>
          <Route path='/EditCategory' element={<EditCategory/>}></Route>
          <Route path='/DeleteCategory' element={<DeleteCategory/>}></Route>
        </Routes>
      </Router>
    </div>
  );
}
export default App;
