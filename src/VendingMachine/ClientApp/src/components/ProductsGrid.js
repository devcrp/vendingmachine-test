import React from "react";
import {
  Col,
  Row,
  Card,
  CardHeader,
  CardBody,
  CardFooter,
  Button,
} from "reactstrap";

const ProductsGrid = (props) => {
  const { products } = props;

  return (
    <Row>
      {products.map((product) => (
        <Col md="3" key={product.id}>
          <Card>
            <CardHeader className="text-center">
              {product.price.toFixed(2)}€
            </CardHeader>
            <CardBody className="text-center">
              <h5>{product.name}</h5>
              <Button
                color="primary"
                className="mt-2"
                onClick={props.onSelectProduct.bind(this, product.id)}
              >
                Select
              </Button>
            </CardBody>
            <CardFooter className="text-center">
              {product.quantity} units
            </CardFooter>
          </Card>
        </Col>
      ))}
    </Row>
  );
};

export default ProductsGrid;
