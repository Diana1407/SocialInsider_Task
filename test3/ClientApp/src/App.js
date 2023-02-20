import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query'

const queryClient = new QueryClient()
console.log(queryClient)

export default class App extends Component {
  static displayName = App.name;

  render() {
      return (
          <QueryClientProvider client={queryClient}>
             <Layout>
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
          </Layout>
          </QueryClientProvider>

    );
  }
}
