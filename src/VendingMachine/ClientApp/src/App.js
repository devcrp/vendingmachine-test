import React, { Component } from "react";
import { Route } from "react-router";
import Layout from "./components/Layout";
import VendingMachine from "./components/VendingMachine";

import "./custom.css";

export default class App extends Component {
  render() {
    return (
      <Layout>
        <Route exact path="/" component={VendingMachine} />
      </Layout>
    );
  }
}
