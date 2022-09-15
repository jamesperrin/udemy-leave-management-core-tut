using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Contracts;

namespace LeaveManagement.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveTypesController(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();

            var model = _mapper.Map<IEnumerable<LeaveTypeVM>>(leaveTypes);

            return View(model);

        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);

            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DefaultDays,Id")] LeaveTypeVM leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                leaveType.DateCreated = DateTime.Now;
                leaveType.DateModified = DateTime.Now;

                await _leaveTypeRepository.AddAsync(leaveType);

                return RedirectToAction(nameof(Index));
            }

            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(id);

            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);

            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Name,DefaultDays,Id")] LeaveTypeVM leaveTypeVM)
        {
            if (id == null || id != leaveTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                    leaveType.DateModified = DateTime.Now;

                    await _leaveTypeRepository.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool leaveTypeExists = await _leaveTypeRepository.Exists(leaveTypeVM.Id);

                    if (!leaveTypeExists)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypeRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
