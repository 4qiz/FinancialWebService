import { Outlet } from "react-router-dom";
import Navbar from "./Components/Navbar/Navbar";
import "react-toastify/dist/ReactToastify.css";
import "./App.css";
import { ToastContainer } from "react-toastify/dist/components";
import { UserProvider } from "./Context/useAuth";

function App() {
  return (
    <>
      <UserProvider>
        <Navbar />
        <Outlet />
        <ToastContainer />
      </UserProvider>
    </>
  );
}

export default App;
