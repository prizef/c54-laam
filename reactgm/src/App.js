import React, { Component } from "react";
import Categories from "./Categories";
import { Route, withRouter } from "react-router-dom";
import "./grid.css";
import DisplayPlaces from "./DisplayPlaces.js";
import styles from "./App.module.css";

const gm = window.gm;

class App extends Component {
  state = {
    vin: "pending...",
    data: gm.info
  };

  componentDidMount() {
    this.props.history.push("/categories");
  }

  handleClose = () => {
    gm.system.closeApp();
  };

  render() {
    return (
      <React.Fragment>
        <button onClick={() => this.handleClose()} />
        <div className={styles.margin} />
        <Route exact path="/categories" component={Categories} />
        <Route exact path="/museums" component={DisplayPlaces} />
      </React.Fragment>
    );
  }
}

export default withRouter(App);
