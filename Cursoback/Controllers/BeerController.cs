﻿using Cursoback.DTOs;
using Cursoback.Model;
using Cursoback.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cursoback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        

        private IValidator<BeerInsertDto> _BeerInsertValidator;
        private IValidator<BeerUpdateDto> _BeerUpdateValidator;
        private ICommonService<BeerDto,BeerInsertDto,BeerUpdateDto> _beerService;


        public BeerController( 
            IValidator<BeerInsertDto> BeerInsertValidator,
            IValidator<BeerUpdateDto> beerUpdateValidator,
            [FromKeyedServices("beerService")]ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto> beerService)
        {

           
            _BeerInsertValidator = BeerInsertValidator;
            _BeerUpdateValidator = beerUpdateValidator;
            _beerService = beerService;

        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() =>
         await _beerService.Get();


        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
           var beerDto = await _beerService.GetById(id);

            return beerDto == null ? NotFound() : Ok(beerDto);
        }


        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            var validationResult = await _BeerInsertValidator.ValidateAsync(beerInsertDto);

            if (!validationResult.IsValid)
            { 
                return BadRequest(validationResult.Errors);
            }

            if (! _beerService.Validate(beerInsertDto))
            { 
                return BadRequest(_beerService.Errors);
            }

            
            var beerDto= await _beerService.Add(beerInsertDto);
           

            return CreatedAtAction(nameof(GetById), new {id =beerDto.Id},beerDto);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<BeerDto>> Update(int id,BeerUpdateDto beerUpdateDto)
        {
            

            var validationResult = await _BeerUpdateValidator.ValidateAsync(beerUpdateDto);

            if (!validationResult.IsValid) 
            {
                return BadRequest(validationResult.Errors);
            }

            if (!_beerService.Validate(beerUpdateDto))
            {
                return BadRequest(_beerService.Errors);
            }


            var beeDto = await _beerService.Update(id, beerUpdateDto);
            

            

            return beeDto == null ? NotFound() : Ok(beeDto);

        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<BeerDto>> Delete(int id) 
        {


            var beeDto = await _beerService.Delete(id);

            return beeDto == null ? NotFound() : Ok(beeDto);


        }

    }
}
