﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace MudBlazor
{
#nullable enable

    /// <summary>
    ///  Represents a floating action button.
    /// </summary>
    public partial class MudFab : MudBaseButton, IHandleEvent
    {
        protected string Classname => new CssBuilder("mud-button-root mud-fab")
            .AddClass($"mud-fab-extended", !string.IsNullOrEmpty(Label))
            .AddClass($"mud-fab-{Color.ToDescriptionString()}")
            .AddClass($"mud-fab-size-{Size.ToDescriptionString()}")
            .AddClass($"mud-ripple", Ripple && !GetDisabledState())
            .AddClass($"mud-fab-disable-elevation", !DropShadow)
            .AddClass(Class)
            .Build();

        /// <summary>
        /// Gets or sets the color of the button.
        /// </summary>
        /// <remarks>
        /// Defaults to <see cref="Color.Default"/>.  Theme colors are supported.
        /// </remarks>
        [Parameter]
        [Category(CategoryTypes.Button.Appearance)]
        public Color Color { get; set; } = Color.Default;

        /// <summary>
        /// Gets or sets the size of the button.
        /// </summary>
        /// <remarks>
        /// Defaults to <see cref="Size.Large"/>.
        /// </remarks>
        [Parameter]
        [Category(CategoryTypes.Button.Appearance)]
        public Size Size { get; set; } = Size.Large;

        /// <summary>
        /// Gets or sets the icon shown before any text.
        /// </summary>
        /// <remarks>
        /// Defaults to <c>null</c>.  Use the <see cref="EndIcon"/> property to show an icon after text.
        /// </remarks>
        [Parameter]
        [Category(CategoryTypes.Button.Behavior)]
        public string? StartIcon { get; set; }

        /// <summary>
        /// Gets or sets the icon shown after any text.
        /// </summary>
        /// <remarks>
        /// Defaults to <c>null</c>.  Use the <see cref="StartIcon"/> property to show an icon before text.
        /// </remarks>
        [Parameter]
        [Category(CategoryTypes.Button.Behavior)]
        public string? EndIcon { get; set; }

        /// <summary>
        /// Gets or sets the color of any icons.
        /// </summary>
        /// <remarks>
        /// Defaults to <see cref="Color.Inherit"/>.  Controls the color of <see cref="StartIcon"/> and <see cref="EndIcon"/> icons.
        /// </remarks>
        [Parameter]
        [Category(CategoryTypes.Button.Appearance)]
        public Color IconColor { get; set; } = Color.Inherit;

        /// <summary>
        /// Gets or sets the size of the icon.
        /// </summary>
        /// <remarks>
        /// Defaults to <see cref="Size.Medium"/>.
        /// </remarks>
        [Parameter]
        [Category(CategoryTypes.Button.Appearance)]
        public Size IconSize { get; set; } = Size.Medium;

        /// <summary>
        /// Gets or sets any text displayed in the button.
        /// </summary>
        /// <remarks>
        /// Defaults to <c>null</c>.
        /// </remarks>
        [Parameter]
        [Category(CategoryTypes.Button.Behavior)]
        public string? Label { get; set; }

        /// <inheritdoc/>
        /// <remarks>
        /// See: https://github.com/MudBlazor/MudBlazor/issues/8365
        /// <para/>
        /// Since <see cref="MudFab"/> implements only single <see cref="EventCallback"/> <see cref="MudBaseButton.OnClick"/> this is safe to disable globally within the component.
        /// </remarks>
        Task IHandleEvent.HandleEventAsync(EventCallbackWorkItem callback, object? arg) => callback.InvokeAsync(arg);
    }
}
