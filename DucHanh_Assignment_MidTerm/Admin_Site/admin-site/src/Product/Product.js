import Table from "react-bootstrap/Table";
import Form from "react-bootstrap/Form";
import { Link } from "react-router-dom";
import { useEffect, useState } from "react";
import { getData, getProductByName } from "../Services/ProductAPI";
import "../css/TableComp.css";
import "../css/Product.css";
export default function Product() {
  //get and load data from API
  const [products, setProducts] = useState([]);
  useEffect(() => {
    loadProducts();
  }, []);
  const loadProducts = async () => {
    const result = await getData();
    setProducts(result.data);
  };
  const loadProductsByName = async (productName) => {
    const result = await getProductByName(productName);
    setProducts(result.data);
  };
  return (
    <div>
      <h3 className="content-label">QUẢN LÝ SẢN PHẨM</h3>
      <Form>
        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Control
            type="email"
            className="search-input"
            placeholder="Sản phẩm cần tìm kiếm..."
            onChange={(e) => {
              loadProductsByName(e.target.value);
            }}
          />
        </Form.Group>
      </Form>
      <Link className="btn btn-success" to="/AddCategory">
        Thêm sản phẩm
      </Link>
      <Table striped bordered hover className="table">
        <thead>
          <tr>
            <th>STT</th>
            <th>Tên thuốc</th>
            <th>Số lượng tồn</th>
            <th>Giá nhập</th>
            <th>Giá bán</th>
            <th>Ngày tạo</th>
            <th>Loại thuốc</th>
            <th>Chức năng</th>
          </tr>
        </thead>
        <tbody>
          {products.map((product, index) => (
            <tr>
              <td key={index}>{index + 1}</td>
              <td>{product.name}</td>
              <td>{product.quantity}</td>
              <td>{product.importPrice}</td>
              <td>{product.price}</td>
              <td>{product.createdDate}</td>
              <td>{product.categoryName}</td>
              <td>
                <Link className="btn btn-primary mx-1" to="/DetailCategory">
                  Xem chi tiết
                </Link>
                <Link className="btn btn-outline-dark mx-1" to="/EditCategory">
                  Cập nhật
                </Link>
                <Link className="btn btn-danger mx-1" to="/DeleteCategory">
                  Xóa
                </Link>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
}
