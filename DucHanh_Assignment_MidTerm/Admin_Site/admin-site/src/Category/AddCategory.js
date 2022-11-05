import React from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import "../css/Form.css";
import { addData } from "../Services/CategoryAPI";

export default function AddCategory() {
    const AddCategory = async (categoryName, categoryDescription) => {
    await addData(categoryName, categoryDescription);
  };
  const handleSubmit = (e) => {
    e.preventDefault();
    const category_name = e.target.name.value;
    const category_description = e.target.description.value;
    if(AddCategory(category_name, category_description))
    {
      alert("Thêm thành công!");
    }
    else
    {
      alert("Thêm thất bại!");      
    }
  };
  return (
    <div>
      <h3 className="content-label">THÊM DANH MỤC</h3>
      <Form className="form" onSubmit={handleSubmit}>
        <Form.Group className="mb-3" controlId="formBasicEmail">
          <Form.Label>Tên danh mục</Form.Label>
          <Form.Control name="name" type="text" placeholder="Tên danh mục..." />
        </Form.Group>
        <Form.Group className="mb-3" controlId="formBasicPassword">
          <Form.Label>Mô tả danh mục</Form.Label>
          <Form.Control
            as="textarea"
            name="description"
            placeholder="Mô tả danh mục..."
            style={{ height: "100px" }}
          />
        </Form.Group>
        <Button type="submit" className="btn-primary center">
          Thêm danh mục
        </Button>
      </Form>
    </div>
  );
}
