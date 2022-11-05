import Table from "react-bootstrap/Table";
import Form from 'react-bootstrap/Form';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import { useEffect, useState } from "react";
import { getData } from "../Services/CategoryAPI";
import { Link } from "react-router-dom";
import "../css/TableComp.css";
export default function Category() {
  //get and load data
  const [categories, setCategories] = useState([]);
  useEffect(() => {
    loadCategories();
  }, []);
  const loadCategories = async () => {
    const result = await getData();
    setCategories(result.data);
  };
  //set global parameter for categoryId
  const setID = (id) => {
    localStorage.setItem("categoryId", id);
  };
  //Render data for column status
  const categoryStatus= (status)=>{
    if(status){
      return <td>Hiện</td> 
    }
    else{
      return <td>Ẩn</td>
    }
  };
  //Modal bootrap for button Delete
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  return (
    <div>
      <h3 className="content-label">QUẢN LÝ DANH MỤC</h3>
      <Link className="btn btn-success" to="/AddCategory">
        Thêm danh mục
      </Link>
      <Table striped bordered hover className="table">
        <thead>
          <tr>
            <th>STT</th>
            <th>Mã danh mục</th>
            <th>Tên danh mục</th>
            <th>Ngày tạo</th>
            <th>Ngày cập nhật</th>
            <th>Trạng thái</th>
            <th>Chức năng</th>
          </tr>
        </thead>
        <tbody>
          {categories.map((category, index) => (
            <tr>
              <td key={index}>{index + 1}</td>
              <td>{category.id}</td>
              <td>{category.name}</td>
              <td>{category.createDate}</td>
              <td>{category.updateDate}</td>
              {categoryStatus(category.status)}
              <td>
                <Link
                  className="btn btn-outline-dark mx-1"
                  to="/EditCategory"
                  onClick={() => setID(category.id)}
                >
                  Cập nhật
                </Link>
                <Link className="btn btn-danger mx-1" onClick={handleShow}>
                  Xóa
                </Link>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Bạn có muốn xóa danh mục này không?</Modal.Title>
        </Modal.Header>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            OK
          </Button>
          <Button variant="primary" onClick={handleClose}>
            Đóng
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
}
