import React from "react";
import { Button } from "reactstrap";

const CoinWrapper = (props) => {
  return (
    <Button
      color="warning"
      className="mx-1 p-2 d-flex align-items-center justify-content-center"
      style={{ height: "50px", width: "50px" }}
      onClick={props.onClick}
    >
      {props.children}
    </Button>
  );
};

export default CoinWrapper;
