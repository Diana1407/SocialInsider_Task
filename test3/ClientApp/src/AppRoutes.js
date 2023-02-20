import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Brands } from "./components/Brands";
import { Profiles } from "./components/Profiles";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
  {
        path: '/fetch-brands',
        element: <Brands />
    },
  {
        path: '/fetch-profiles',
        element: <Profiles />
    }
];

export default AppRoutes;
