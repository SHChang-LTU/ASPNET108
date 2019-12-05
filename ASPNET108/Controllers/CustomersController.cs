﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNET108.Models;
using Vidly.ViewModels;

namespace ASPNET108.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id ==id);

            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers
                .Include(c=>c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                TryUpdateModel(customer);

                _context.Entry(customer).State = EntityState.Modified;


                //var customerInDb =
                //    _context.Customers.Single(c => c.Id == customer.Id);

                //customerInDb.Name = customer.Name;
                //customerInDb.BirthDate = customer.BirthDate;
                //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId;
                //customerInDb.Credit = customer.Credit;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}