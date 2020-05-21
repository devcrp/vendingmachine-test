import React from "react";
import CoinWrapper from "./CoinWrapper";

const Five = (props) => {
  return (
    <CoinWrapper onClick={props.onClick.bind(this, 0.05)}>0.05€</CoinWrapper>
  );
};

export default Five;
