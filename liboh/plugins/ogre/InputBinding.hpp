/*  Sirikata liboh -- Ogre Graphics Plugin
 *  InputBinding.hpp
 *
 *  Copyright (c) 2009, Ewen Cheslack-Postava
 *  All rights reserved.
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions are
 *  met:
 *  * Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 *  * Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in
 *    the documentation and/or other materials provided with the
 *    distribution.
 *  * Neither the name of Sirikata nor the names of its contributors may
 *    be used to endorse or promote products derived from this software
 *    without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS
 * IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
 * TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 * PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER
 * OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
 * EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 * PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
 * PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 * LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

#ifndef _SIRIKATA_INPUT_BINDING_HPP_
#define _SIRIKATA_INPUT_BINDING_HPP_

#include <util/Platform.hpp>
#include "input/InputEventDescriptor.hpp"
#include "input/InputEvents.hpp"
#include "InputBindingEvent.hpp"
#include "InputResponse.hpp"

namespace Sirikata {
namespace Graphics {

class InputBinding {
    typedef std::map<Input::EventDescriptor, InputResponse*> Binding;
public:
    InputBinding();
    ~InputBinding();

    void add(const InputBindingEvent& evt, InputResponse* response);

    void handle(Input::ButtonEventPtr& evt);
    void handle(Input::ButtonPressedEventPtr& evt);
    void handle(Input::ButtonReleasedEventPtr& evt);
    void handle(Input::ButtonDownEventPtr& evt);
    void handle(Input::AxisEventPtr& evt);
    void handle(Input::TextInputEventPtr& evt);
    void handle(Input::MouseHoverEventPtr& evt);
    void handle(Input::MouseClickEventPtr& evt);
    void handle(Input::MouseDragEventPtr& evt);
    void handle(Input::WindowEventPtr& evt);
    void handle(Input::DragAndDropEventPtr& evt);

private:
    Binding mResponses;
}; // class InputBinding

} // namespace Graphics
} // namespace Sirikata

#endif //_SIRIKATA_INPUT_BINDING_HPP_
