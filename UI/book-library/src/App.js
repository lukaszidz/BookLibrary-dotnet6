import React, { useState } from "react";
import styles from "./App.css";
import Books from "./components/Books";

const App = () => {
  return (
    <main className={styles.container}>
      <div className={styles.wrapper}>
        <Books />
      </div>
    </main>
  );
};

export default App;