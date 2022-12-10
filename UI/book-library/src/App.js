import React from "react";
import styles from "./styles/app.module.css";
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